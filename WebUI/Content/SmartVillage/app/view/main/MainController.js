Ext.define('SmartVillage.view.main.MainController', {
    extend: 'Ext.app.ViewController',

    requires: [
        'Ext.window.MessageBox'
    ],

    alias: 'controller.main',

    showCountry: function () {
       this.getView().layout.centerRegion.removeAll();
       this.getView().layout.centerRegion.add(Ext.widget('country'));
    }
});
