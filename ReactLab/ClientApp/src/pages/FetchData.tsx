import React, { Component } from 'react';
import { Dropdown } from 'primereact/dropdown';
import { Button } from 'primereact/button';
import { DropdownProps } from 'reactstrap';

export interface FetchDataState {
  forecasts: any[],
  loading: boolean
  city: string;
}

export interface FetchDataOption {

}

export class FetchData extends Component<DropdownProps, FetchDataState> {
  static displayName = FetchData.name;

  constructor(props: FetchDataOption) {
    super(props);
    this.state = { forecasts: [], loading: true,city:'' };
    this.handleClick = this.handleClick.bind(this);
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts: any[]) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    const citySelectItems = [
      { label: 'New York', value: 'NY' },
      { label: 'Rome', value: 'RM' },
      { label: 'London', value: 'LDN' },
      { label: 'Istanbul', value: 'IST' },
      { label: 'Paris', value: 'PRS' }
    ];

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>

        <Dropdown value={this.state.city} options={citySelectItems} onChange={(e) => this.setCity(e.value)} placeholder="Select a City" />
        <Button label="Save" onClick={this.handleClick}  />
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  setCity(value: string) {
    this.setState({
      city: value
    });
  }

  handleClick(){
    alert(this.state.city)
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
