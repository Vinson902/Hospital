<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <p>{{something}}</p>
        <p>Welcome to your new single-page application, built with <a href="https://vuejs.org" target="_blank">Vue.js</a>.</p>
    </div>
</template>

<script>
    export default {
        name: 'Home',
        props: {
            msg: String,
            something: String
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

