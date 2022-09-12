import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { strings: ["Hello", "World", "How do you do?"], loading: false };
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : App.renderStrings(this.state.strings);

        return (
            <div>
                <h1 id="tabelLabel" >API Demo With Strings</h1>
                <p>This component demonstrates interacting with a .NET API.</p>
                {contents}
            </div>
        );
    }
    /*
    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
    */
    static renderStrings(strings) {
        return (
            <ul>
                {strings.map(item =>
                    <li key={item}>{item}</li>
                )}
            </ul>
        );
    }




}
