using System;

namespace VectorRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var vector1 = new Vector(1, 0, 0);
            var orient = new Orientation(Math.PI , Math.PI , Math.PI );
            var matrixX = RotationalMatrix.SetMatrixX(orient.Roll);
            var matrixY = RotationalMatrix.SetMatrixY(orient.Pitch);
            var matrixZ = RotationalMatrix.SetMatrixZ(orient.Yaw);

            var matrixXY = RotationalMatrix.MultMatrix(matrixX, matrixY);
            var matrixXYZ = RotationalMatrix.MultMatrix(matrixXY, matrixZ);

            var newVector = RotationalMatrix.MultMatrixVector(matrixXYZ, vector1);

            Console.WriteLine(newVector);
            Console.ReadLine();
        }
    }
}
