using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(Church.Droid.CustomRenderers.AndroidLabelRenderer))]
namespace Church.Droid.CustomRenderers
{
    class AndroidLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            
        }

              
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ((e.PropertyName == Label.FontFamilyProperty.PropertyName) || (e.PropertyName == Label.FontProperty.PropertyName))
            {
				Typeface tf = Typeface.CreateFromAsset(Context.Assets, "ProximaNovaRegular.ttf");
				if(Control != null)
				{
					Control.SetTypeface(tf, TypefaceStyle.Normal);
				}
            }
        }
    }
}