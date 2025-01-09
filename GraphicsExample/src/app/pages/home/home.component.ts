import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NgxEchartsDirective, provideEchartsCore } from 'ngx-echarts';
import { EChartsOption } from 'echarts';
//PIE
import { TooltipComponent } from 'echarts/components';
import { LegendComponent } from 'echarts/components';
//LINE
import { TitleComponent } from 'echarts/components';
import { LineChart } from 'echarts/charts';

// import necessary echarts components
import * as echarts from 'echarts/core';
import { BarChart, PieChart } from 'echarts/charts';
import { GridComponent } from 'echarts/components';
import { CanvasRenderer } from 'echarts/renderers';
echarts.use([BarChart, GridComponent, CanvasRenderer, PieChart, TooltipComponent, LegendComponent, TitleComponent, LineChart]);

@Component({
  selector: 'app-home',
  imports: [CommonModule, NgxEchartsDirective],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  providers: [
    provideEchartsCore({ echarts })
  ]
})
export class HomeComponent {
  exibeGrafico: boolean = false;
  exibeGrafico2: boolean = false;

  exibir() { this.exibeGrafico = !this.exibeGrafico; }
  exibir2() { this.exibeGrafico2 = !this.exibeGrafico2; }
  //BAR
  chartOption: EChartsOption = {
    xAxis: {
      type: 'category',
      data: ['January/2024', 'February/2024', 'March/2024', 'April/2024', 'May/2024', 'June/2024', 'July/2024', 'August/2024', 'September/2024', 'October/2024', 'November/2024', 'December/2024'],
      axisLabel: {
        rotate: 30,
        interval: 0
      }
    },
    yAxis: {
      type: 'value'
    },
    series: [
      {
        name: 'Sales (mil)',
        type: 'bar',
        data: [{value: 30, itemStyle: {color: '#32a850'}}, 99, 78, 56, 25, 69, 90, 29, 12, 87, 91, 121],
        label: {
          show: true,
          position: 'top',
          formatter: '{c} mil (MT)'
        },
        itemStyle: {
          color: '#674f77'
        }
      }
    ],
    animation: true,
    animationEasing: 'backOut',
    animationDuration: 2000
  };

  //PIE
  chartOption2: EChartsOption = {
    tooltip: {
      trigger: 'item'
    },
    legend: {
      orient: 'vertical',
      left: 'left'
    },
    series: [
      {
        name: 'Sales (mil)',
        type: 'pie',
        radius: '50%',
        data: [
          { value: 30, name: 'January/2024', itemStyle: { color: '#32a850' } },
          { value: 99, name: 'February/2024', itemStyle: { color: '#50a8c0' } },
          { value: 78, name: 'March/2024', itemStyle: { color: '#a832c0' } }
        ],
        emphasis: {
          itemStyle: {
            shadowBlur: 10,
            shadowOffsetX: 0,
            shadowColor: 'rgba(0, 0, 0, 0.5)'
          }
        },
        label: {
          show: true,
          formatter: '{b}: {c} mil (MT)'
        }
      }
    ]
  };

  //LINE
  chartOption3: EChartsOption = {
    title: {
      text: 'Sales Price',
      left: 'center'
    },
    tooltip: {
      trigger: 'axis',
      formatter: '{b0}: ${c0}'
    },
    xAxis: {
      type: 'category',
      data: ['2024-01-01', '2024-01-02', '2024-01-03', '2024-01-04', '2024-01-05', '2024-01-06', '2024-01-07', '2024-01-08', '2024-01-09', '2024-01-10', '2024-01-11', '2024-01-12', '2024-01-13', '2024-01-14', '2024-01-15', '2024-01-16', '2024-01-17', '2024-01-18', '2024-01-19', '2024-01-20', '2024-01-21'],
      axisLabel: {
        formatter: function (value: string) {
          return value.split('-').slice(1).join('/'); // Formato MM/DD
        }
      }
    },
    yAxis: {
      type: 'value',
      axisLabel: {
        formatter: '{value} MT'
      }
    },
    series: [
      {
        name: 'Price',
        type: 'line',
        data: [4500, 46000, 4700, 46500, 8000, 5500, 76000, 7700, 77800, 80000, 4500, 46000, 4700, 46500, 80000, 4500, 46000, 4700, 46500, 80000, 90000],
        smooth: true,
        lineStyle: {
          color: '#5470C6',
          width: 2
        },
        areaStyle: {
          color: 'rgba(84, 112, 198, 0.2)'
        },
        itemStyle: {
          color: '#5470C6'
        },
        showSymbol: false // Remove os pontos na linha para um visual mais limpo
      }
    ]
  };

  // line 2
  chartOption4: EChartsOption = {
    xAxis: {
      type: 'category',
      data: ['January/2024', 'February/2024', 'March/2024', 'April/2024', 'May/2024', 'June/2024', 'July/2024', 'August/2024', 'September/2024', 'October/2024', 'November/2024', 'December/2024'],
      axisLabel: {
        rotate: 30,
        interval: 0
      }
    },
    yAxis: {
      type: 'value'
    },
    series: [
      {
        name: 'Sales (mil)',
        type: 'line',
        data: [{value: 30, itemStyle: {color: '#32a850'}}, 99, 78, 56, 25, 69, 90, 29, 12, 87, 91, 121],
        label: {
          show: true,
          position: 'top',
          formatter: '{c} mil (MT)'
        },
        itemStyle: {
          color: '#674f77'
        }
      }
    ],
    animation: true,
    animationEasing: 'backOut',
    animationDuration: 2000
  };

  // LINE AND BAR
  chartOption5: EChartsOption = {
    xAxis: {
      type: 'category',
      data: ['January/2024', 'February/2024', 'March/2024', 'April/2024', 'May/2024', 'June/2024', 'July/2024', 'August/2024', 'September/2024', 'October/2024', 'November/2024', 'December/2024'],
      axisLabel: {
        rotate: 30,
        interval: 0
      }
    },
    yAxis: {
      type: 'value'
    },
    series: [
      {
        name: 'Sales (mil)',
        type: 'line',
        data: [{value: 30, itemStyle: {color: '#32a850'}}, 99, 78, 56, 25, 69, 90, 29, 12, 87, 91, 121],
        label: {
          show: true,
          position: 'top',
          formatter: '{c} mil (MT)'
        },
        itemStyle: {
          color: '#38f0da'
        }
      },
      {
        name: 'Sales (mil)',
        type: 'bar',
        data: [{value: 30, itemStyle: {color: '#32a850'}}, 99, 78, 56, 25, 69, 90, 29, 12, 87, 91, 121],
        itemStyle: {
          color: '#674f77'
        }
      }
    ],
    animation: true,
    animationEasing: 'backOut',
    animationDuration: 2000
  };
}
