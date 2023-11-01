using fukicycle.blazor.neumorphism.components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fukicycle.blazor.neumorphism.components.Control
{
    public partial class InputBox<T>
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? Attributes { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; } = string.Empty;

        [Parameter]
        public string Type { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<ChangeEventArgs> OnChanged { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnInputChanged { get; set; }

        [Parameter]
        public T Value { get; set; } = default!;

    }
}
