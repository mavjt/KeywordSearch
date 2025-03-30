import { React, useState, useRef } from 'react';
import SearchButton from "./SearchButton";
import TextField from "./TextField";
import SearchEngineList from "./SearchEngineList";

export default function SearchForm({ availableEngines, populateHistory }) {
    const [isWaiting, setIsWaiting] = useState(false);
    const [keywordText, setKeywordText] = useState('');
    const [urlText, setUrlText] = useState('');
    const [selectedEngines, setSelectedEngines] = useState([]);
    const formRef = useRef(null);

    async function startNewSearch(e) {
        e.preventDefault();
       
        setIsWaiting(true);
        console.log(`${keywordText} - ${urlText}`);
        console.log(selectedEngines);
        setIsWaiting(false);
        
        try {
            const response = await fetch('api/KeywordSearch', {
                method: 'POST',
                body: JSON.stringify({ keywords: keywordText, url: urlText, searchEngines: selectedEngines }),
                headers: {
                    'Content-Type': 'application/json'
                }
            });

            if (response.ok) {
                setIsWaiting(false);
                populateHistory();
                //    throw new Error(`Response status: ${response.status}`);
            }
            else {
                setIsWaiting(false);
                throw new Error(`Response status: ${response.errors}`)
            }
            ////const json = await response.json();
            //console.log(response);
        }
        catch (error) {
            alert('Sorry, something has gone wrong');
            console.error(error);
        }
        setIsWaiting(false);
    }


    return (
        <>
            <form ref={formRef} id="keywordsearch" onSubmit={(e) => startNewSearch(e).then(res => {
                if (!res) {
                    console.log('reset');
                    formRef.current.reset();
                }
            })}>
                <div>
                    <TextField fieldlabel="Keywords" id="txtKeywords" value={keywordText} onTextChange={setKeywordText} />
                </div>
                <div>
                    <TextField fieldlabel='Url to match' value={urlText} onTextChange={setUrlText} />
                </div>
                <div>
                    {availableEngines.length > 0 && <SearchEngineList labels={availableEngines} selected={selectedEngines} setSelected={setSelectedEngines} />}
                </div>
                <div>
                    <SearchButton  isWaiting={isWaiting} />
                </div>
            </form>
        </>
    )
}