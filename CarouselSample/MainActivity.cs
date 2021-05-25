using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Syncfusion.Carousel;
using Android.Graphics;
using Android.Content;
using Android.Provider;
using System;
using System.Collections.Generic;

namespace CarouselSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       SfCarousel carousel;
        List<SfCarouselItem> tempCollection = new List<SfCarouselItem>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            LinearLayout layout = new LinearLayout(this);
            carousel = new SfCarousel(this);
            Button button = new Button(this);
            button.Click += Button_Click;
            button.Text = "Load Image";
            button.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, 150);
            carousel.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            layout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            layout.AddView(button, 0);
            layout.AddView(carousel, 1);

            layout.Orientation = Orientation.Vertical;
            
            SetContentView(layout);
        }

        static int PICK_IMAGES = 1;
        private void Button_Click(object sender, System.EventArgs e)
        {
            InitializeMediaPicker();
        }
        public void InitializeMediaPicker()
        {
            Intent = new Intent();
            Intent.PutExtra(Intent.ExtraAllowMultiple, true);
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PICK_IMAGES);
        }

       
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            tempCollection.Clear();
            if (requestCode == PICK_IMAGES)
            {
                if (data.ClipData != null)
                {
                    ClipData mClipData = data.ClipData;
                    for (int i = 0; i < mClipData.ItemCount; i++)
                    {
                        ClipData.Item item = mClipData.GetItemAt(i);
                        var uri = item.Uri;
                        ImageView imageView = new ImageView(this);
                        imageView.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(carousel.ItemWidth, carousel.ItemHeight);
                        imageView.SetScaleType(ImageView.ScaleType.FitXy);
                        imageView.SetImageURI(uri);
                        tempCollection.Add(new SfCarouselItem(this) { ContentView = imageView });
                    }

                    carousel.DataSource = tempCollection;

                }
                else if (data.Data != null)
                {
                    var uri = data.Data;
                    ImageView imageView = new ImageView(this);
                    imageView.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(carousel.ItemWidth, carousel.ItemHeight);
                    imageView.SetScaleType(ImageView.ScaleType.FitXy);
                    imageView.SetImageURI(uri);
                    tempCollection.Add(new SfCarouselItem(this) { ContentView = imageView });
                   
                }
                carousel.DataSource = tempCollection;

            }
         
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}