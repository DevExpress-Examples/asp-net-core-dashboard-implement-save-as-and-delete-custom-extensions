class SaveAsDashboardExtension {
    toolbox;
    menuItem;
    dashboardControl;
    name = "dashboard-save-as";
    newName = ko.observable("New Dashboard Name");

    constructor(dashboardControl) {
        this.dashboardControl = dashboardControl;
        this.menuItem = {
            id: "dashboard-save-as",
            title: "Save As...",
            template: "dx-save-as-form",
            selected: ko.observable(true),
            disabled: ko.computed(function () { return !dashboardControl.dashboard(); }),
            index: 112,
            data: this
        };
    }

    saveAs() {
        if (this.isExtensionAvailable()) {
            this.toolbox.menuVisible(false);
            this.newDashboardExtension.performCreateDashboard(this.newName(), this.dashboardControl.dashboard().getJSON());
        }
    }

    isExtensionAvailable() {
        return this.toolbox !== undefined && this.newDashboardExtension !== undefined;
    }

    start() {
        this.toolbox = this.dashboardControl.findExtension("toolbox");
        this.newDashboardExtension = this.dashboardControl.findExtension("createDashboard");

        if (this.isExtensionAvailable())
            this.toolbox.menuItems.push(this.menuItem);
    }
    stop() {
        if (this.isExtensionAvailable())
            this.toolbox.menuItems.remove(this.menuItem);
    }
}
