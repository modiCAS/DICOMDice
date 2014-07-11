using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace DicomDice
{
    public class DiceLabels3D : ModelVisual3D
    {
        private Brush _foreground;
        private FontFamily _fontFamily;
        private string _caption;
        private string _minorLabel;
        private string _majorLabel;
        private double _rotationAngle;
        private Vector3D _rotationAxis;
        private bool _changing;

        public double RotationAngle
        {
            get { return _rotationAngle; }
            set
            {
                _rotationAngle = value;
                Rebuild();
            }
        }

        public Vector3D RotationAxis
        {
            get { return _rotationAxis; }
            set
            {
                _rotationAxis = value;
                Rebuild();
            }
        }

        public Brush Foreground
        {
            get { return _foreground; }
            set
            {
                _foreground = value;
                Rebuild();
            }
        }

        public FontFamily FontFamily
        {
            get { return _fontFamily; }
            set
            {
                _fontFamily = value;
                Rebuild();
            }
        }

        public string MajorLabel
        {
            get { return _majorLabel; }
            set
            {
                _majorLabel = value;
                Rebuild();
            }
        }

        public string MinorLabel
        {
            get { return _minorLabel; }
            set
            {
                _minorLabel = value;
                Rebuild();
            }
        }

        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                Rebuild();
            }
        }

        private void Rebuild()
        {
            if ( _changing ) return;
            _changing = true;

            Children.Clear();

            Children.Add( GenerateLabel( 6, 0, 0, 0, MajorLabel ) );
            Children.Add( GenerateLabel( 2, 2, 2, 0.001, MinorLabel ) );
            Children.Add( GenerateLabel( 1, 0, -3, 0.001, Caption ) );

            Transform = new RotateTransform3D( new AxisAngleRotation3D( RotationAxis, RotationAngle ) );

            _changing = false;
        }

        private TextVisual3D GenerateLabel( int height, double x, double y, double offset, string text )
        {
            return new TextVisual3D
            {
                Foreground = Foreground,
                Height = height,
                FontFamily = FontFamily,
                FontWeight = FontWeights.Normal,
                IsDoubleSided = false,
                Position = new Point3D( x, -5.001 - offset, y ),
                UpDirection = new Vector3D( 0, 0, 1 ),
                TextDirection = new Vector3D( 1, 0, 0 ),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = text
            };
        }
    }
}