module.exports = {
    content: [
        './Pages/**/*.cshtml', // Razor pages
        './Views/**/*.cshtml', // MVC views
        './Areas/**/*.cshtml',
        './wwwroot/**/*.html', // Other HTML files
        './src/**/*.js', 
    ],
    theme: {
        extend: {},
        colors: {
            Primary: "rgb(var(--color-primary) / <alpha-value> )",
            Secondary: "rgb(var(--color-secondary) / <alpha-value> )",
            ThirdColor: "rgb(var(--color-third) / <alpha-value> )",
            ColorWhite: "rgb(var(--text-color-white) / <alpha-value> )",
            ColorBlack: "rgb(var(--text-color-black) / <alpha-value>)"
          
        },
    },
    plugins: [],
}