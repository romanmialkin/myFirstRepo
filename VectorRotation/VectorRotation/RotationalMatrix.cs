using System;
using System.Collections;

namespace VectorRotation
{
    public class RotationalMatrix
    {
        public double[,] Matrix { get; set; }

        public RotationalMatrix() { }

        public RotationalMatrix(double[,] matrix)
        {
            Matrix = matrix;
        }

        public static RotationalMatrix SetMatrixX(double angle)
        {
            var matrixX = new RotationalMatrix(
                new double[,]{ {1, 0, 0}, 
                                {0, Math.Cos(angle), -Math.Sin(angle)},
                                {0, Math.Sin(angle), Math.Cos(angle)} });
            return matrixX;           
        }

        public static RotationalMatrix SetMatrixY(double angle)
        {
            var matrixY = new RotationalMatrix(
                new double[,]{ {Math.Cos(angle), 0, Math.Sin(angle)},
                                {0, 1, 0},
                                {-Math.Sin(angle), 0, Math.Cos(angle)} });
            return matrixY;
        }

        public static RotationalMatrix SetMatrixZ(double angle)
        {
            var matrixZ = new RotationalMatrix(
                new double[,]{ {Math.Cos(angle), -Math.Sin(angle), 0},
                                {Math.Sin(angle), Math.Cos(angle), 0},
                                {0, 0, 1} });
            return matrixZ;
        }

        public static RotationalMatrix MultMatrix(RotationalMatrix m1, RotationalMatrix m2)
        {
            var matrixXY = new RotationalMatrix(new double[3, 3]);

            for (int i = 0; i <= matrixXY.Matrix.Rank; i++)
                for (int j = 0; j <= matrixXY.Matrix.Rank; j++)
                {
                    matrixXY.Matrix[i, j] = m1.Matrix[i, 0] * m2.Matrix[0, j] +
                                    m1.Matrix[i, 1] * m2.Matrix[1, j] +
                                    m1.Matrix[i, 2] * m2.Matrix[2, j];
                }

            return matrixXY;
        }

        public static Vector MultMatrixVector(RotationalMatrix m, Vector vector)
        {
            var vectorResult = new Vector(
                m.Matrix[0, 0] * vector.X + m.Matrix[0, 1] * vector.Y +
                        m.Matrix[0, 2] * vector.Z,
                m.Matrix[1, 0] * vector.X + m.Matrix[1, 1] * vector.Y +
                        m.Matrix[1, 2] * vector.Z,
                m.Matrix[2, 0] * vector.X + m.Matrix[2, 1] * vector.Y +
                        m.Matrix[2, 2] * vector.Z);

            return vectorResult;
        }

    }
}
