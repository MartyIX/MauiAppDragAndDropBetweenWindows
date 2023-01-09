namespace MauiAppDragAndDropBetweenWindows;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnShowNewWindowClicked(object sender, EventArgs e)
    {
        MainPage mainPage = new();

        Window window = new()
        {
            Title = "Window 2",
            Page = mainPage,
        };

        Application.Current!.OpenWindow(window);
    }

    public void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        GestureRecognizer recognizer = (GestureRecognizer)sender;
        e.Data.Properties.Add("MyImage", (Image)recognizer.Parent);
    }

    public void OnImageDrop(object sender, DropEventArgs e)
    {
        Image droppedImage = (Image)e.Data.Properties["MyImage"];

        droppedImage.Opacity = 0.5;
        SourceZone.Remove(droppedImage);
        MyDropZone.Add(droppedImage);
    }
}