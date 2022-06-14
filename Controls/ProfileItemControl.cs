using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WSEIDziekanat.Controls;

public sealed class ProfileItemControl : Control
{
    public static readonly DependencyProperty LeftTextProperty =
       DependencyProperty.Register(
           "LeftText",
           typeof(string),
           typeof(ProfileItemControl),
           new PropertyMetadata(default(string)));


    public static readonly DependencyProperty RightTextProperty =
       DependencyProperty.Register(
           "RightText",
           typeof(string),
           typeof(ProfileItemControl),
           new PropertyMetadata(default(string)));

    public string LeftText
    {
        get { return (string)GetValue(LeftTextProperty); }
        set { SetValue(LeftTextProperty, value); }
    }

    public string RightText
    {
        get { return (string)GetValue(RightTextProperty); }
        set { SetValue(RightTextProperty, value); }
    }

    public ProfileItemControl()
    {
        DefaultStyleKey = typeof(ProfileItemControl);
    }
}