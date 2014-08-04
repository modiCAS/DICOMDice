using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace DicomDice
{
    public partial class MainWindow
    {
        private readonly Point3D _originalPosition;
        private readonly Vector3D _originalUpDirection;
        private readonly Vector3D _originalLookDirection;

        public MainWindow()
        {
            InitializeComponent();

            _originalPosition = Viewport.Camera.Position;
            _originalUpDirection = Viewport.Camera.UpDirection;
            _originalLookDirection = Viewport.Camera.LookDirection;
        }

        private void ResetCamera( object sender, ExecutedRoutedEventArgs e )
        {
            Viewport.Camera.Position = _originalPosition;
            Viewport.Camera.UpDirection = _originalUpDirection;
            Viewport.Camera.LookDirection = _originalLookDirection;
        }

        private void PopContextMenu( object sender, RoutedEventArgs routedEventArgs )
        {
            var host = sender as FrameworkElement;
            if ( host == null ) return;

            host.ContextMenu.PlacementTarget = host;
            host.ContextMenu.IsOpen = true;
        }

        private void ResetCube( object sender, ExecutedRoutedEventArgs e )
        {
            Dice.Transform = new MatrixTransform3D( Matrix3D.Identity );
        }
    }
}
