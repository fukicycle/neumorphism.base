using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace fukicycle.Blazor.Neumorphism.Design.Base
{
    public partial class Neumorphism
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? Attributes { get; set; }

        [Parameter]
        public RenderFragment ChildContent
        {
            get => _childContent;
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                if (_childContent != value)
                {
                    _childContent = value;
                }
            }
        }

        [Parameter]
        public ShapeType ShapeType
        {
            get => _shapeType;
            set
            {
                if (value != _shapeType)
                {
                    _shapeType = value;
                    OnSettingChanged();
                }
            }
        }

        [Parameter]
        public LightLocation LightLocation
        {
            get => _lightLocation;
            set
            {
                if (value != _lightLocation)
                {
                    _lightLocation = value;
                    OnSettingChanged();
                }
            }
        }

        [Parameter]
        public string BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                OnSettingChanged();
            }
        }


        private RenderFragment _childContent = null!;
        private ShapeType _shapeType = ShapeType.FLOAT;
        private LightLocation _lightLocation = LightLocation.TOP_LEFT;
        private BaseColor _color = ColorSetting.BaseColor;

        private string _style = "";

        private static int _offset = 3;
        private static int _blur = _offset * 2;
        private string _borderRadius = ".7rem";

        protected override void OnInitialized()
        {
            OnSettingChanged();
        }


        private void OnSettingChanged()
        {
            string baseColor = _color.GetBaseColor();
            string darkColor = _color.GetDarkColor();
            string lightColor = _color.GetLightColor();
            _style = $"border-radius: {_borderRadius}; ";
            if (ShapeType == ShapeType.SINK)
            {
                _style += $"background: {baseColor};";
                switch (LightLocation)
                {
                    case LightLocation.TOP_LEFT:
                        _style += $"box-shadow: inset {_offset}px {_offset}px {_blur}px {darkColor}, inset -{_offset}px -{_offset}px {_blur}px {lightColor};";
                        break;
                    case LightLocation.TOP_RIGHT:
                        _style += $"box-shadow: inset -{_offset}px {_offset}px {_blur}px {darkColor}, inset {_offset}px -{_offset}px {_blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_LEFT:
                        _style += $"box-shadow: inset {_offset}px -{_offset}px {_blur}px {darkColor}, inset -{_offset}px {_offset}px {_blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_RIGHT:
                        _style += $"box-shadow: inset -{_offset}px -{_offset}px {_blur}px {darkColor}, inset {_offset}px {_offset}px {_blur}px {lightColor};";
                        break;
                }
            }
            else
            {

                switch (ShapeType)
                {
                    case ShapeType.FLOAT:
                        _style += $"background: {baseColor};";
                        break;
                    case ShapeType.CONVEX:
                        _style += $"background: linear-gradient(145deg, {darkColor}, {lightColor});";
                        break;
                    case ShapeType.CONCAVE:
                        _style += $"background: linear-gradient(145deg, {lightColor}, {darkColor});";
                        break;
                }
                switch (LightLocation)
                {
                    case LightLocation.TOP_LEFT:
                        _style += $"box-shadow: {_offset}px {_offset}px {_blur}px {darkColor}, -{_offset}px -{_offset}px {_blur}px {lightColor};";
                        break;
                    case LightLocation.TOP_RIGHT:
                        _style += $"box-shadow: -{_offset}px {_offset}px {_blur}px {darkColor}, {_offset}px -{_offset}px {_blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_LEFT:
                        _style += $"box-shadow: {_offset}px -{_offset}px {_blur}px {darkColor}, -{_offset}px {_offset}px {_blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_RIGHT:
                        _style += $"box-shadow: -{_offset}px -{_offset}px {_blur}px {darkColor}, {_offset}px {_offset}px {_blur}px {lightColor};";
                        break;
                }
            }
            StateHasChanged();
        }
    }
}
