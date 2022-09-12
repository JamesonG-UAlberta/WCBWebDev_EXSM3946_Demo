﻿const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/examplereact",
    "/ExampleReact"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7048',
        secure: false
    });

    app.use(appProxy);
};
