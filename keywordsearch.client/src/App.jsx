import { useEffect, useState } from 'react';
import './App.css';
import ShowHistoryButton from "./ShowHistoryButton";
import SearchForm from "./SearchForm";

function App() {
    const [history, setHistory] = useState();
    const [engineLabels, setEngineLabels] = useState([]);      
  

    useEffect(() => {
        getAvailableEngines();
    }, []);


    async function populateHistory() {
        const response = await fetch('api/SearchHistory');
        if (response.ok) {
            const data = await response.json();
            setHistory(data);
        }
    }

    const contents = history === undefined

        ? <p><em>To see the history, click 'View history' or start a new search above.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Keywords</th>
                    <th>Url</th>
                    <th>SearchEngine</th>
                    <th>Results</th>
                    <th>Date</th>
                </tr>
            </thead>
            <tbody>
                {history.map(row =>
                    <tr key={row.searchDate}>
                        <td>{row.keywords}</td>
                        <td>{row.url}</td>
                        <td>{row.searchEngine}</td>
                        <td>{row.results}</td>
                        <td>{formatDate(row.searchDate)}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div className="container">
            <h1 id="tableLabel">Search Engine Tool</h1>
           
            <SearchForm availableEngines={engineLabels} populateHistory={() => populateHistory()} />
            <hr />
            
            <ShowHistoryButton handleClick={populateHistory} />
            {contents}
        </div>
    );

    

    function formatDate(dt) {
        let actualdt = new Date(dt);
        return `${actualdt.toLocaleTimeString("en-GB", {
            hour: "2-digit",
            minute: "2-digit",
        })} ${actualdt.toLocaleDateString("en-GB")}`;
    }
    

    async function getAvailableEngines() {
        const response = await fetch('api/SearchEngineLookup');
        if (response.ok) {
            const data = await response.json();
            setEngineLabels(data);
        }
        else {
            setEngineLabels([])
        }
    }
}

export default App;
