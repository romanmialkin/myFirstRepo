using System;

namespace VectorRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var vector1 = new Vector(5, 2, 1);
            var orient = new Orientation(Math.PI, Math.PI, Math.PI / 4 );
            var matrixX = RotationalMatrix.SetMatrixX(orient.Roll);
            var matrixY = RotationalMatrix.SetMatrixY(orient.Pitch);
            var matrixZ = RotationalMatrix.SetMatrixZ(orient.Yaw);

            //var matrixXY = RotationalMatrix.MultMatrix(matrixX, matrixY);
            //var matrixXYZ = RotationalMatrix.MultMatrix(matrixXY, matrixZ);

            var newVector = RotationalMatrix.MultMatrixVector(matrixX, vector1);
            var newVector2 = RotationalMatrix.MultMatrixVector(matrixY, newVector);
            var resVector = RotationalMatrix.MultMatrixVector(matrixZ, newVector2);

            Console.WriteLine(resVector);
            Console.ReadLine();
        }
    }
}
