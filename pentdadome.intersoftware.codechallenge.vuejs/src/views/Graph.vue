<template>
  <div id="container" style="width:100%; height:400px;">
    
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Highcharts from 'highcharts'
import axios from 'axios'
import Sale from '@/models/Sale'

@Options({})
export default class Graph extends Vue {
  hasBeenLoaded = false;
  graphData : Sale[] = [];
  
}
</script>
