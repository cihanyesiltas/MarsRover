﻿using System;
using System.Linq;
using MarsRover.Infrastructure.Contracts;
using MarsRover.Infrastructure.DTOs;
using MarsRover.Infrastructure.Enums;
using MarsRover.Infrastructure.Extensions;
using MarsRover.Infrastructure.Validators;

namespace MarsRover.Infrastructure
{
    public class Rover
    {
        private Coordinate _coordinate;
        private Orientation _orientation;
        private readonly Plateau _plateau;
        private readonly ICommandFactory _commandFactory;

        public Rover(Plateau plateau, ICommandFactory commandFactory)
        {
            _plateau = plateau;
            _commandFactory = commandFactory;
        }

        public void TurnLeft()
        {
            switch (_orientation)
            {
                case Orientation.North:
                    _orientation = Orientation.West;
                    break;
                case Orientation.East:
                    _orientation = Orientation.North;
                    break;
                case Orientation.South:
                    _orientation = Orientation.East;
                    break;
                case Orientation.West:
                    _orientation = Orientation.South;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (_orientation)
            {
                case Orientation.North:
                    _orientation = Orientation.East;
                    break;
                case Orientation.East:
                    _orientation = Orientation.South;
                    break;
                case Orientation.South:
                    _orientation = Orientation.West;
                    break;
                case Orientation.West:
                    _orientation = Orientation.North;
                    break;
            }
        }

        public void MoveForward()
        {
            switch (_orientation)
            {
                case Orientation.North:
                    _coordinate.Y++;
                    break;
                case Orientation.East:
                    _coordinate.X++;
                    break;
                case Orientation.South:
                    _coordinate.Y--;
                    break;
                case Orientation.West:
                    _coordinate.X--;
                    break;
            }
        }

        public void SetPosition(SetPositionDTO dto)
        {
            var validator = new SetRoverPositionValidator().Validate(dto);
            if (!validator.IsValid)
            {
                throw new Exception(validator.Errors.Select(a => a.ErrorMessage).FirstOrDefault());
            }

            var splittedPosition = dto.PositionLetter.Split(' ');

            _coordinate = new Coordinate {X = int.Parse(splittedPosition[0]), Y = int.Parse(splittedPosition[1])};

            _orientation = splittedPosition[2].GetEnumByDescription<Orientation>();
        }

        public void RunCommandList(RunCommandListDTO dto)
        {
            var validator = new RunCommandListValidator().Validate(dto);
            if (!validator.IsValid)
            {
                throw new Exception(validator.Errors.Select(a => a.ErrorMessage).FirstOrDefault());
            }

            var commandLetterList = dto.CommandLetters.ToArray();

            foreach (var commandLetter in commandLetterList)
            {
                var command = _commandFactory.GetCommand(commandLetter);
                command.Execute(this);
            }
        }

        public string GetPosition()
        {
            return $"{_coordinate.X} {_coordinate.Y} {_orientation.ToDescription()}";
        }
    }
}