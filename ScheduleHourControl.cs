using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Shapes;

namespace WSEIDziekanat;

[TemplatePart(Name = "cellMiddle", Type = typeof(StackPanel))]
[TemplatePart(Name = "line", Type = typeof(Line))]
public sealed class ScheduleHourControl : Control
{
    public ScheduleHourControl()
    {
        DefaultStyleKey = typeof(ScheduleHourControl);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("cellMiddle") is StackPanel cellMiddle)
            cellMiddle.SizeChanged += CellMiddle_SizeChanged;
    }

    private void CellMiddle_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (sender is StackPanel cellMiddle && GetTemplateChild("line") is Line line)
            line.X2 = cellMiddle.ActualWidth - 1;
    }
}
