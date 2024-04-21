
using Core.FrontEnds.Libraries.Portal;
using Core.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.FrontEnds.Sites.MainPage.Projects.Web.Modules
{
    public partial class Portfodio : Module
    {
        protected override void BeforeInitData()
        {
            var result = Randomize(Items);
            result.BindTo(rpWebs);
        }




        public List<WebItem> Items = new List<WebItem>
        {
            //Web nhà đất nè
            new WebItem{Code = " BDS01", Intro="Mẫu web nhà đất", Target="bds", Avatar="/Projects/Web/Resources/images/webs/home_bds_01.JPG", Url="/trang-chu-home-for-rent-template"},
            new WebItem{Code = " BDS02", Intro="Mẫu web nhà đất", Target="bds", Avatar="/Projects/Web/Resources/images/webs/home_bds_02.JPG", Url="/trang-chu-landing-contruction-template"},
            new WebItem{Code = " BDS03", Intro="Mẫu web nhà đất", Target="bds", Avatar="/Projects/Web/Resources/images/webs/home_bds_03.JPG", Url="/trang-chu-home-for-sale-template"},
            new WebItem{Code = " BDS04", Intro="Mẫu web nhà đất", Target="bds", Avatar="/Projects/Web/Resources/images/webs/home_bds_04.JPG", Url="/trang-chu-home-land-template"},

            //Landing page
            new WebItem{Code = " LAD01", Intro="Mẫu landing page", Target="landing", Avatar="/Projects/Web/Resources/images/webs/landing1.JPG", Url="/trang-chu-landing-design-template"},
            new WebItem{Code = " LAD02", Intro="Mẫu landing page", Target="landing", Avatar="/Projects/Web/Resources/images/webs/landing2.JPG", Url="/trang-chu-landing-company-template"},   
            new WebItem{Code = " LAD03", Intro="Mẫu landing page", Target="landing", Avatar="/Projects/Web/Resources/images/webs/landing3.JPG", Url="/trang-chu-landing-software-template"},
            new WebItem{Code = " LAD04", Intro="Mẫu landing page", Target="landing", Avatar="/Projects/Web/Resources/images/webs/landing4.jpg", Url="/trang-chu-landing-edu-template"},
            new WebItem{Code = " LAD05", Intro="Mẫu landing page", Target="landing", Avatar="/Projects/Web/Resources/images/webs/home_bds_02.JPG", Url="/trang-chu-landing-contruction-template"},
            new WebItem{Code = " LAD06", Intro="Mẫu Landing page nhà hàng", Target="landing", Avatar="/Projects/Web/Resources/images/webs/restaurant.JPG", Url="/trang-chu-landing-restro-template"},

            //Web bán hàng
            new WebItem{Code = " SHOP01", Intro="Mẫu web bán hàng", Target="shop", Avatar="/Projects/Web/Resources/images/webs/shop1.JPG", Url="/trang-chu-shop-clother-template"},
            new WebItem{Code = " SHOP02", Intro="Mẫu web bán hàng", Target="shop", Avatar="/Projects/Web/Resources/images/webs/shop2.JPG", Url="/trang-chu-shop-vegetable-template"},
            new WebItem{Code = " SHOP03", Intro="Mẫu web bán hàng", Target="shop", Avatar="/Projects/Web/Resources/images/webs/shop3.JPG", Url="/trang-chu-shop-jewelry-template"},
            new WebItem{Code = " SHOP04", Intro="Mẫu web bán hàng", Target="shop", Avatar="/Projects/Web/Resources/images/webs/shop4.JPG", Url="/trang-chu-shop-mobile-template"},

            //Web rao vặt
            new WebItem{Code = " TMDT01", Intro="Mẫu web rao vặt", Target="tmdt", Avatar="/Projects/Web/Resources/images/webs/tmdt_01.JPG", Url="/trang-chu-classified-ads-template"},
            new WebItem{Code = " TMDT02", Intro="Mẫu web rao vặt", Target="tmdt", Avatar="/Projects/Web/Resources/images/webs/tmdt_02.JPG", Url="/trang-chu-classified-all-template"},
            new WebItem{Code = " TMDT03", Intro="Mẫu web rao vặt", Target="tmdt", Avatar="/Projects/Web/Resources/images/webs/tmdt_03.JPG", Url="/trang-chu-classified-ads-template"},

            //Web khác.v.v.
            new WebItem{Code = " RES01", Intro="Mẫu web nhà hàng", Target="res", Avatar="/Projects/Web/Resources/images/webs/restaurant.JPG", Url="/trang-chu-landing-restro-template"},
            new WebItem{Code = " BLOG01", Intro="Mẫu web blogspot", Target="blog", Avatar="/Projects/Web/Resources/images/webs/blogsot1.JPG", Url="/trang-chu-video-streaming-template"},
            new WebItem{Code = " BLOG02", Intro="Mẫu web blogspot", Target="blog", Avatar="/Projects/Blogspots/Blog_Game/Resources/Cap.jpg", Url="/trang-chu-blog-game-template"},
        };

        







        public static List<WebItem> Randomize(List<WebItem> input)
        {
            List<WebItem> output = new List<WebItem>();
            Random rand = new Random();
            while (input.Count > 0)
            {
                int index = rand.Next(input.Count);
                output.Add(input[index]);
                input.RemoveAt(index);
            }
            return output;
        }

    }

    public class WebItem
    {
        public string Code { get; set; }
        public string Intro { get; set; }
        public string Target { get; set; }
        public string Avatar { get; set; }
        public string Url { get; set; }
        public string Title { get => Intro + ": " + Code; } 
    }
}