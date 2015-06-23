Ext.define('SmartVillage.view.main.Main', {
    extend: 'Ext.container.Container',

    plugins: 'viewport',

    requires: [
        'SmartVillage.view.main.MainController',
        'SmartVillage.view.main.MainModel',
        'SmartVillage.view.country.Country'
    ],

    xtype: 'app-main',

    controller: 'main',
    viewModel: {
        type: 'main'
    },

    layout: {
        type: 'border'
    },

    items: [
        {
            xtype: 'panel',
            region: 'west',
            title: 'Довідники',
            split: true,
            collapsible: true,
            width: 230,
            lbar: [
                {
                    xtype: 'button',
                    text: 'Країни',
                    handler: 'showCountry',
                    scale: 'large'
                }
            ]
        },
        {
            xtype: 'panel',
            bind: {
                title: '{name}'
            },
            region: 'north'
        },
        {
            xtype: 'panel',
            region: 'center'
        }
    ]
});