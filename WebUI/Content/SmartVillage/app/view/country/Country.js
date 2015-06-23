Ext.define('SmartVillage.view.country.Country', {
    extend: 'Ext.container.Container',

    requires: [
        'SmartVillage.controller.Country'
    ],

    xtype: 'country',

    controller: 'country',

    layout: {
        type: 'container'
    },

    defaults: {
        xtype: 'gridpanel',
        flex: 1,
        style: {
            margin: '10px 10px 10px 10px'
        }
    },

    items: [{
        xtype: 'gridpanel',
        store: 'Countries', 
        title: 'Країни',
        frame: true,
        width: 300,
        columns: [{
            header: 'Назва', dataIndex: 'Name', flex: 1
        }],
        tbar: [{
            text: 'Новий',
            handler: 'new'
        }]
    }]
});