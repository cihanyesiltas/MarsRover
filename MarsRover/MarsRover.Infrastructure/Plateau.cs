using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Infrastructure.Validators;

namespace MarsRover.Infrastructure
{
    public class Plateau
    {
        public Coordinate LowerLeftCoordinate { get; private set; }

        public Coordinate UpperRightCoordinate { get; private set; }

        public Plateau(string upperRigthCoordinateLetter)
        {
            SetUpperRightCoordinate(upperRigthCoordinateLetter);
            InitiliazeDefaultLowerLeftCoordinate();
            GetOutOfBoundaryList = new List<Coordinate>();
        }

        public bool CheckBoundaries(Coordinate coordinate)
        {
            return LowerLeftCoordinate.X <= coordinate.X && LowerLeftCoordinate.Y <= coordinate.Y
                                                         && UpperRightCoordinate.X >= coordinate.X &&
                                                         UpperRightCoordinate.Y >= coordinate.Y;
        }

        public List<Coordinate> GetOutOfBoundaryList { get; }

        public void SetOutOfCoordinate(Coordinate coordinate)
        {
            GetOutOfBoundaryList.Add(coordinate);
        }

        private void SetUpperRightCoordinate(string upperRigthCoordinateLetter)
        {
            var validator = new PlateauUpperRightCoordinateLetterValidator().Validate(upperRigthCoordinateLetter);
            if (!validator.IsValid)
            {
                throw new Exception(validator.Errors.Select(a => a.ErrorMessage).FirstOrDefault());
            }

            var splittedLetter = upperRigthCoordinateLetter.Split(' ');
            UpperRightCoordinate = new Coordinate { X = int.Parse(splittedLetter[0]), Y = int.Parse(splittedLetter[1]) };
        }

        private void InitiliazeDefaultLowerLeftCoordinate()
        {
            LowerLeftCoordinate = new Coordinate { X = 0, Y = 0 };
        }
    }
}
