Ext.define('SmartVillage.model.Country', {
    extend: 'Ext.data.Model',
    fields: ['ID', 'Name'],
    autoLoad: true,
    proxy: {
        type: 'ajax',
        url: '/api/country',
        reader: {
            type: 'json'//,
            //rootProperty: 'results'
        }
    }
});