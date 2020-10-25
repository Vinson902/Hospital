<template>
    <div id="app">
        <Home msg="Hello world!" something="123" />
    </div>
</template>

<script>
    import Home from './components/Home.vue'
    export default {
        name: 'app',
        components: {
            Home
        },
    
    data(){
        return{
            regions: [],
            generalPractise: [],
            patients: []
        }
    },
    beforeMount () {
    fetch('https://localhost:5001/api/region')
      .then(Response => {
        return Response.json()
      })
      .then(JsonData => {
        this.regions = JsonData
      })
      fetch('https://localhost:5001/api/Gp')
      .then(Response => {
        return Response.json()
      })
      .then(JsonData => {
        this.generalPractise = JsonData
      })
      fetch('https://localhost:5001/api/patient')
      .then(Response => {
        return Response.json()
      })
      .then(JsonData => {
        this.patients = JsonData
      })
  }
};

</script>

<style>
</style>
