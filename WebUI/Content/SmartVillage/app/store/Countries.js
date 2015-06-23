Ext.define('SmartVillage.store.Countries', {
    extend: 'Ext.data.Store',
    requires: 'SmartVillage.model.Country',
    model: 'SmartVillage.model.Country',
    xtype: 'country-store',
    autoLoad : true
});