import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    // 1. Constructor sets a list of default strings.
    constructor(props) {
        super(props);
        this.state = { strings: ["Hello", "World", "How do you do?"], count:0, loadingList: false, loadingCount: false };
    }

    // 2. Render the list of default strings to the page with a refresh button. Rest.
    // 4. Render fires and sets the loading message, and awaits another state change.
    // 6. Render fires and updates the page with the new data that has returned. Rest.
    // If the button is clicked again, it starts again from step 3.
    render() {
    // Start thread A.
        let contents = this.state.loadingList || this.state.loadingCount
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
                <p>There are currently {this.state.count} items stored in the server's cache.</p>
                {contents}

                <button onClick={(() => {
                    // 3. When the button is clicked, set the state loading to true and begin the fetch method. Changing state triggers render to fire.
                    this.setState({ loading: true });
                    this.populateCount();
                    // Start thread B.
                    // (Thread A continues)
                    this.populateStrings(); 
                    // Start thread C.
                    // (Thread A continues)
                }).bind(this)

                }>Refresh</button>
            </div>
        );
        // Thread A ends.
    }

    async populateCount() {
        const responseCount = await fetch('examplereact/count');
        const dataCount = await responseCount.json();
        this.setState({ count: dataCount, loading: false });
        // Thread B ends.
    }

    // 5. Fetch the strings and update the state with the new data and turn off loading when the data gets back.
    async populateStrings() {
        const responseList = await fetch('examplereact/list');
        const dataList = await responseList.json();
        this.setState({ strings: dataList, loading: false });
        // Thread C ends.
    }
}
