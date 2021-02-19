<template>
  <div id="container" style="width:100%; height:400px;">

  </div>
    <div id="container2" style="width:100%; height:400px;">

  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import ProductMonthlySaleRecord from '@/models/ProductMonthlySaleRecord'
import Highcharts, { Axis, Chart, SeriesLineOptions, SeriesOptionsType } from 'highcharts'
import axios from 'axios'
import Sale from '@/models/Sale'

const months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

@Options({})
export default class Graph extends Vue {
  chart: Highcharts.Chart|null = null;
  chartTurnover: Highcharts.Chart|null = null;

  created () {
    axios.get<ProductMonthlySaleRecord[]>('https://localhost:44393/api/sales/GetSalesByMonth').then(x => {
      const graphDataAmountSold = x.data.map(x => ({ name: x.product, data: x.saleRecords.map(y => y.quantity), type: 'line' })) as SeriesLineOptions[]
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
        series: graphDataAmountSold
      })
      const graphDataTurnover = x.data.map(x => ({ name: x.product, data: x.saleRecords.map(y => y.turnOver), type: 'line' })) as SeriesLineOptions[]
      this.chartTurnover = Highcharts.chart({
        chart: {
          renderTo: 'container2'
        },
        title: {
          text: 'Turnover of Product By month'
        },
        xAxis: {
          categories: months
        },
        yAxis: {
          title: {
            text: 'Amount in Euros'
          }
        },
        series: graphDataTurnover
      })
    })
  };
}
</script>
