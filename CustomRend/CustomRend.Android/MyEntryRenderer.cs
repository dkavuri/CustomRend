using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomRend;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Runtime.CompilerServices;
using CustomRend.Droid;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]

namespace CustomRend.Droid
{
    class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (MyEntry) Element;
                SetTextAlignment(view);
                SetPlaceholderTextColor(view);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (MyEntry)Element;

       
            if (e.PropertyName == MyEntry.XAlignProperty.PropertyName)
                SetTextAlignment(view);
           
            if (e.PropertyName == MyEntry.PlaceholderTextColorProperty.PropertyName)
                SetPlaceholderTextColor(view);
           
        }
        private void SetTextAlignment(MyEntry view)
        {
            switch (view.XAlign)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    Control.Gravity = GravityFlags.CenterHorizontal;
                    break;

                case Xamarin.Forms.TextAlignment.End:
                    Control.Gravity = GravityFlags.End;
                    break;

                case Xamarin.Forms.TextAlignment.Start:
                    Control.Gravity = GravityFlags.CenterVertical;
                    break;
            }
        }

        private void SetPlaceholderTextColor(MyEntry view)
        {
            if (view.PlaceholderTextColor != Xamarin.Forms.Color.Default)
                Control.SetHintTextColor(view.PlaceholderTextColor.ToAndroid());
        }
    }
}