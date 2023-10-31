using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fukicycle.blazor.neumorphism.components.Control
{
    public partial class SelectBox<T>
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? Attributes { get; set; }

        [Parameter]
        public IEnumerable<T> Items
        {
            get => _items;
            set
            {
                if (_items != value && value is not null)
                {
                    _items = value;
                    UpdateItems();
                }
            }
        }

        [Parameter]
        public string ValueMemberPath { get; set; } = "ID";

        [Parameter]
        public string DisplayMemberPath { get; set; } = "Name";

        [Parameter]
        public EventCallback<ChangeEventArgs> SelectionChanged { get; set; }

        [Parameter]
        public bool IsDefaultItem { get; set; } = false;

        [Parameter]
        public string DefaultItemMessage { get; set; } = "Select a item";

        private IEnumerable<T> _items = Enumerable.Empty<T>();
        private IEnumerable<SelectBoxItem> _displayItems = Enumerable.Empty<SelectBoxItem>();

        private void UpdateItems()
        {
            List<SelectBoxItem> displayItems = new List<SelectBoxItem>();
            foreach (T item in _items)
            {
                long id = long.Parse(typeof(T).GetProperties().FirstOrDefault(a => a.Name.ToLower() == ValueMemberPath.ToLower())?.GetValue(item)?.ToString() ?? "0");
                string name = typeof(T).GetProperties().FirstOrDefault(a => a.Name.ToLower() == DisplayMemberPath.ToLower())?.GetValue(item)?.ToString() ?? "";
                displayItems.Add(new SelectBoxItem
                {
                    ID = id,
                    Name = name
                });
            }
            _displayItems = displayItems;
            StateHasChanged();
        }

        public class SelectBoxItem
        {
            public long ID { get; set; }
            public string Name { get; set; } = null!;
        }
    }
}
