function Chart_ObjectHotTracked(s, e) {
    if (e.hitInfo.inSeriesPoint && !e.hitInfo.inSeriesLabel)
        chart.SetCursor('hand');
    else
        chart.SetCursor('');
}

function Chart_ObjectSelected(s, e) {
    if (e.hitInfo.inSeriesPoint && !e.hitInfo.inSeriesLabel) {
        var selectedPoint = e.additionalHitObject;

        document.getElementById('hfOriginalArgument').value = _aspxGetInvariantDateTimeString(_aspxToUtcTime(selectedPoint.argument));
        teArgument.SetDate(_aspxToUtcTime(selectedPoint.argument));
        tbValue.SetText(selectedPoint.values[0]);

        popup.Show();
    }
}

function Ok_Click(s, e) {
    popup.Hide();
    chart.PerformCallback(_aspxGetInvariantDateTimeString(teArgument.GetDate()) + ';' + tbValue.GetText());
}

function Cancel_Click(s, e) {
    popup.Hide();
}