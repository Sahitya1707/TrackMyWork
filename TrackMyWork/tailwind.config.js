module.exports = {
    content: [
        './Pages/**/*.{cshtml, razor}',
        './Views/**/*.{cshtml,razor}',
        "./wwwroot/js/**/*.js"
    ],
    theme: {
        extend: {},
        colors: {
            primary: "rgb(var(--color-primary) / <alpha-value> )",
            secondary: "rgb(var(--color-secondary) / <alpha-value> )",
            thirdColor: "rgb(var(--color-third) / <alpha-value> )",
            ColorWhite: "rgb(var(--text-color-white) / <alpha-value> )",
            ColorBlack: "rgb(var(--text-color-black) / <alpha-value>)"
          
        },
    },
    plugins: [],
}