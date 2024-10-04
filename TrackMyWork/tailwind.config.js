module.exports = {
    content: [
        './Pages/**/*.{cshtml, razor}',
        './Views/**/*.{cshtml,razor}',
        "./wwwroot/js/**/*.js"
    ],
    theme: {
        extend: {},
        colors: {
            primary: "rgb(var(--color-primary) / <alpha-value>)",
            secondary: "rgb(var(--color-secondary) / <alpha-value> )",
            thirdColor: "rgb(var(--color-third) / <alpha-value> )",
            textColor: "rgb(var(--text-color) / <alpha-value> )",
          
        },
    },
    plugins: [],
}