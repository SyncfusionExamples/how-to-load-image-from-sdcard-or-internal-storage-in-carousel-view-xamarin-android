# How to load images from SD card or Url in Carousel control

In General, you can assign carousel item images from the Resource folder of the application when using image content. On the other hand, carousel control provides support to load the images from an SD card or a URL that can be assigned as content.

You can load images from an SD card or a URL in Xamarin.Forms carousel control. The following steps will help you to load images:

*   Step 1: Add the needed assemblies to have carousel control.

*   Step 2: Create an ObservableCollection to hold image data.

*   Step 3: While adding an image to an ObservableCollection, if it is in URL format, include the URL link; otherwise, if the image is in SD format, include the location of the image.

The following code example illustrates how to load the images from an SD card and from a URL

## Getting Carousel’s Image from URL:

**[XAML]**
```
<carousel:SfCarousel x:Name="carousel"  
                             ItemTemplate="{StaticResource itemTemplate}" 
                             ItemsSource="{Binding ImageCollection}" 
                             HeightRequest="400" 
                             WidthRequest="800" 
                             ItemHeight="{OnPlatform Android='250',iOS='300'}"
                             ItemWidth="{OnPlatform Android='170',iOS='150'}"/>
```
**[C#]**
```
public class KBViewModel
    {
        public KBlViewModel()
        {
           ImageCollection.Add(new CarouselModel("https://cdn.syncfusion.com/content/images/
                                                 Images/ Camtasia_Succinctly.png?v=22022017060923"));
 
            ImageCollection.Add(new CarouselModel("https://cdn.syncfusion.com/content/images/
                                                 Images/SQL_Queries_Succinctly.png?v=04022017014551"));
 
            ImageCollection.Add(new CarouselModel("https://cdn.syncfusion.com/content/images/
                                                      Images/Keystonejs_Succinctly.png?v=22022017060923"));
 
            ImageCollection.Add(new CarouselModel("https://cdn.syncfusion.com/content/images/
             Images/sql_server_for_c_sharp_developers_succinctly_cover_img.png?v=22022017060923"));
 
            ImageCollection.Add(new CarouselModel("https://cdn.syncfusion.com/content/
                 images/downloads/ebooks/SciPy_Programming_Succinctly_img.png?v=22022017060923"));
        }
 
        private List<CarouselModel> _imageCollection = new List<CarouselModel>();
 
        public List<CarouselModel> ImageCollection
        {
            get { return _imageCollection; }
            set { _imageCollection = value; }
        }
 
    }
public class CarouselModel
    {
        public CarouselModel(string imageString)
        {
            Image = imageString;
        }
 
        private string _image;
 
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
```
## Getting Carousel’s Image from SD card location:

**[XAML]**

```
<carousel:SfCarousel x:Name="carousel"  
                             ItemTemplate="{StaticResource itemTemplate}" 
                             ItemsSource="{Binding ImageCollection}" 
                             HeightRequest="400" 
                             WidthRequest="800" 
                             ItemHeight="{OnPlatform Android='250',iOS='300'}"
                             ItemWidth="{OnPlatform Android='170',iOS='150'}"/>
```
**[C#]**
```
<carousel:SfCarousel x:Name="carousel"  
                             ItemTemplate="{StaticResource itemTemplate}" 
                             ItemsSource="{Binding ImageCollection}" 
                             HeightRequest="400" 
                             WidthRequest="800" 
                             ItemHeight="{OnPlatform Android='250',iOS='300'}"
                             ItemWidth="{OnPlatform Android='170',iOS='150'}"/>
```
