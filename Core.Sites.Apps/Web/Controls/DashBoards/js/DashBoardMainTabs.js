function DashBoardMainTabs()
{
    $.extend(this, new ModuleBase());

    this.init = function (res) 
    { 
        this.main.elementHeader.hide();
        this.getMain().onCTab(this);
        this.getMain().find("[data-db-tab-id]").eq(0).click();
    };
    this.tab_CustomerData = function (data, tab) { data.TabId = tab.attr("data-db-tab-id"); };
    this.modules = [];
    this.tab_BeforeInit = function (module, res, tab) 
    { 
        var $this = this;
        module.dashboard.tabId = tab.attr("data-db-tab-id");
        module.dashboard.onDashBoardChangeTab = function(tabIdToChange)
        {
            $.data($this.getMain().find("[data-db-tab-id=" + tabIdToChange + "]")[0], "hasLoad", false);
        }
        this.modules.push(module); 
    };
    this.end = function()
    {
        this.main.elementHeader.show();
        for (var i = 0; i < this.modules.length; i++) this.modules[i].end();
    }
}