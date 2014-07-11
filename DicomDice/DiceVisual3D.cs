using System.Collections.Generic;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace DicomDice
{
    public class DiceVisual3D : MeshElement3D
    {
        private Point3D _center;
        private double _sideLength = 1;
        private double _chamfer = 0.1;

        public Point3D Center
        {
            get { return _center; }
            set
            {
                _center = value;
                OnGeometryChanged();
            }
        }

        public double SideLength
        {
            get { return _sideLength; }
            set
            {
                _sideLength = value;
                OnGeometryChanged();
            }
        }

        public double Chamfer
        {
            get { return _chamfer; }
            set
            {
                _chamfer = value;
                OnGeometryChanged();
            }
        }

        protected override MeshGeometry3D Tessellate()
        {
            var diceMesh = new MeshBuilder();
            diceMesh.AddBox( Center, SideLength, SideLength, SideLength );

            var halfLength = SideLength / 2;

            for ( int i = 0; i < 2; i++ )
            {
                double x = i * SideLength;

                for ( int j = 0; j < 2; j++ )
                {
                    double y = j * SideLength;

                    for ( int k = 0; k < 2; k++ )
                    {
                        double z = k * SideLength;

                        var points = new List<Point3D>();
                        diceMesh.ChamferCorner( new Point3D( x - halfLength, y - halfLength, z - halfLength ),
                            SideLength * Chamfer, SideLength * 1e-6, points );
                    }
                }
            }

            return diceMesh.ToMesh();
        }
    }
}