﻿using System;
using System.Net;
using DiscountTracker.MainService.Managers.Abstraction;
using HtmlAgilityPack;

namespace DiscountTracker.MainService.Managers
{
    public class VatanManager:IECommerceManager
    {
        public double GetPrice(string productUrl)
        {
            Uri url = new Uri(productUrl);
            WebClient client = new WebClient();
            string html = client.DownloadString(url); // html kodları indiriyoruz.

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html); // html kodlarını bir HtmlDocment nesnesine yüklüyoruz.
            HtmlNode priceNode = document.DocumentNode.SelectSingleNode("//span[@class='product-list__price']"); // a etiketlerinin içerisinden class haberbas olanları seçiyoruz.

            var price = Convert.ToDouble(priceNode.InnerHtml);

            return price;

        }
    }
}
