using System;
using System.Collections.Generic;
using System.Linq;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using Xceed.Document.NET;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public class ListCreator
    {
        public static List AddNewList<TViewModel>(Document document, string listPropertyName, HomeViewModel homeViewModel)
        where TViewModel : ViewModelBase
        {
            List<string> resourceNames = new();
            var list = document.AddList("", 0, ListItemType.Numbered, 1);

            var resourceList = homeViewModel.GetType().GetProperty(listPropertyName);

            if (resourceList is null)
            {
                return list;
            }

            if (resourceList.GetValue(homeViewModel) is List<TViewModel> resourceProperty)
            {
                resourceNames.AddRange(resourceProperty.Select(item => item.GetType().GetProperty("Name")
                                                                          ?.GetValue(item).ToString() ?? string.Empty));
            }

            resourceNames.ForEach(name => document.AddListItem(list, name));

            return list;
        }
    }
}