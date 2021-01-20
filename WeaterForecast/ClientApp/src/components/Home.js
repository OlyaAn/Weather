import authService from './api-authorization/AuthorizeService'
import React, { Component } from 'react';
import { Button, Input, Item} from 'semantic-ui-react';
import 'semantic-ui-css/semantic.min.css';
import dateFormat from 'dateformat';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = {
      forecasts: [],
      loading: false,
      location: null
    };
  }

  populateWeatherData = this.populateWeatherData.bind(this)

  handleChange = event => {
    this.setState({ location: event.target.value });
  };

  static renderForecastsTable(forecasts) {
    return (
      <Item.Group>         
        {forecasts.map(forecast => 
          <Item key={forecast.id}>
            <Item.Image size='tiny'  src={`https://www.metaweather.com/static/img/weather/png/${forecast.weather_state_abbr}.png`} />
            <Item.Content>
              <Item.Header as='a'>{dateFormat(forecast.applicable_date, "dd/mm/yyyy")}</Item.Header>
              <Item.Meta>{forecast.weather_state_name}</Item.Meta>
              <Item.Extra>Min Temp: {forecast.min_temp}</Item.Extra>
              <Item.Extra>Man Temp: {forecast.max_temp}</Item.Extra>
            </Item.Content>
          </Item>)}   
      </Item.Group>)
  };

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Home.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <Input type='text' placeholder='Search...' onChange={this.handleChange}  action>
        <input />
        <Button type='submit' onClick={this.populateWeatherData}>Search</Button></Input>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    this.setState({ loading: true});
    const token = await authService.getAccessToken();
    let location = this.state.location;
    const response = await fetch(`weatherforecast/Location/${location}`, {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const locationId = await response.json();
    const forecastResponse = await fetch(`weatherforecast/locationWeather/${locationId}`, {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const forecastData = await forecastResponse.json();
    console.log(forecastData);
    this.setState({ forecasts: forecastData, loading: false });
    ;
  }
}
