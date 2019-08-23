using System;
using Android.Graphics;
using AppBancaEnLinea2C2019.Droid.CustomRenderers;
using AppBancaEnLinea2C2019.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(FontAwesomeLabel), typeof(FontAwesomeLabelRenderer))]
namespace AppBancaEnLinea2C2019.Droid.CustomRenderers
{
    public class FontAwesomeLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets,
                    FontAwesomeLabel.FontAwesomeName + ".otf");
            }
        }
       
    }
}
