import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    // 1. Call Constructor
    constructor(props) {
        super(props);
        // 2. Constructor sets state which invokes render.
        this.state = { forecasts: [], loading: true };
    }

    // 4. After the initial run of render, componentDidMount runs (if it mounts successfully).
    componentDidMount() {
        // 5. componentDidMount runs populateWeatherData.
        this.populateWeatherData();
    }

    // 3. Render runs (with no data, and loading true).
    // 7. Render runs again (with the data stored in state, and loading false).
    // 9. Once the data is present, no more method calls or state changes, so react rests and the user sees the final page.
    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    // 6. populateWeatherData runs and updates the state, which then invokes render again.
    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }

    // 8. Render the table based on the data. 
    static renderForecastsTable(forecasts) {
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




}
