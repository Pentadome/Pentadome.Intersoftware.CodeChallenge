<template>
  <div id="container" style="width:100%; height:400px;">

  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import ProductMonthlySaleRecord from '@/models/ProductMonthlySaleRecord'
import Highcharts, { Axis, Chart, SeriesLineOptions, SeriesOptionsType } from 'highcharts'
import axios from 'axios'
import Sale from '@/models/Sale'

const months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

@Options({})
export default class Graph extends Vue {
  chart: Highcharts.Chart|null = null;
  created () {
    axios.get<ProductMonthlySaleRecord[]>('https://localhost:44393/api/sales/GetSalesByMonth').then(x => {
      const graphData = x.data.map(x => ({ name: x.product, data: x.saleRecords.map(y => y.quantity), type: 'line' })) as SeriesLineOptions[];
      this.chart = Highcharts.chart({
        chart: {
          renderTo: 'container'
        },
        title: {
          text: 'Product Sales By month'
        },
        xAxis: {
          categories: months
        },
        yAxis: {
          title: {
            text: 'Amount Sold'
          }
        },
        series: graphData
      })
    })
  };
}
</script>
