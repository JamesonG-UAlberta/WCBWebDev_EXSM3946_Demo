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
            : <ul>
                {this.state.strings.map(item =>
                    <li key={item}>{item}</li>
                )}
              </ul>;

        return (
            <div>
                <h1 id="tabelLabel" >API Demo With Strings</h1>
                <p>This component demonstrates interacting with a .NET API.</p>
                {contents}
                <button onClick={(() => { this.setState({ loading: true }); this.populateStrings(); }).bind(this)}>Refresh</button>
            </div>
        );
    }
    async populateStrings() {
        const response = await fetch('examplereact');
        console.log(response);
        const data = await response.json();
        this.setState({ strings: data, loading: false });
    }

    




}
