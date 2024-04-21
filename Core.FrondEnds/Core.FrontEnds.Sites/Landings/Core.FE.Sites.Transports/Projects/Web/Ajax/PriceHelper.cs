using Core.Business.Entities.Others.PriceConfigs;
using Core.FrontEnds.Libraries.Web;
using Core.FrontEnds.Libraries.Web.Caches.Orthers.PriceConfigs;
using Core.Web.WebBase;
using System.Linq;


namespace Core.FE.Sites.Transports.Projects.Web.Ajax
{
    public class PriceHelper: IAjax
    {
        public void GetPrice(int? startPoint, int? endPoint, int? productType, TranType? containerType, int LanguageId)
        {
            if (startPoint == null || endPoint == null || productType == null || containerType == null)
            {
                string messages = string.Empty;
                switch (LanguageId)
                {
                    case 1:
                        {
                            messages = "Please enter complete information before getting a price!";
                            break;
                        }
                    case 3:
                        {
                            messages = "获取价格前请输入完整信息！";
                            break;
                        }
                    case 4:
                        {
                            messages = "価格を取得する前に完全な情報を入力してください。";
                            break;
                        }
                    case 5:
                        {
                            messages = "가격을 받기 전에 전체 정보를 입력하세요!";
                            break;
                        }
                }
                this.SetData("Error", true);
                this.SetData("Message", messages);
            }
            else
            {
                var prices = CachePriceConfigs.GetData();
                var current = prices.FirstOrDefault(c => c.StartDirection == startPoint && c.EndDirection == endPoint && c.ProductType == productType && c.ContainerType == containerType);
                if (current != null)
                {
                    this.SetData("Error", false);
                    string result = string.Empty;
                    result = current.Price.ToString("0,00") + " VND";
                    this.SetData("Result", result);
                }
                else
                {
                    string messages = string.Empty;
                    switch (FeContext.Url.LanguageId)
                    {
                        case 1:
                            {
                                messages = "Please enter complete information before getting a price!";
                                break;
                            }
                        case 3:
                            {
                                messages = "获取价格前请输入完整信息！";
                                break;
                            }
                        case 4:
                            {
                                messages = "価格を取得する前に完全な情報を入力してください。";
                                break;
                            }
                        case 5:
                            {
                                messages = "가격을 받기 전에 전체 정보를 입력하세요!";
                                break;
                            }
                    }
                    this.SetData("Error", true);
                    this.SetData("Message", messages);
                }
            }
            
        }
    }
}