import { React, useState, useRef } from 'react';
import SearchButton from "./SearchButton";
import TextField from "./TextField";
import SearchEngineList from "./SearchEngineList";
import { useForm } from "react-hook-form"


export default function SearchForm({ availableEngines, populateHistory }) {
    const [isWaiting, setIsWaiting] = useState(false);    
    const formRef = useRef(null);

    const { register, handleSubmit, formState: { errors } } = useForm({
        defaultValues: { keywords: "", url: "", searchEngines :[] } }) 

    const onSubmitTest = function(data) {
        console.log(errors);
        console.log(data)
      
    }
    async function startNewSearch(data) {
        setIsWaiting(true);
        
        console.log(data);

        try {
            const response = await fetch('api/KeywordSearch', {
                method: 'POST',
                body: JSON.stringify(data), 
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

    const ValidatorRequired = { required: "Keywords are  required" };
    const ValidatorUrl = {
        required: "Url required", pattern: {
            value: /^(https?:\/\/)?(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_+.~#?&//=]*)/,
            message: "That doesn't look like a website."
        },
    };

    return (
        <>
            <form ref={formRef} id="keywordsearch" onSubmit={handleSubmit(startNewSearch)}>
                <TextField label="Keywords" field="keywords" register={register} required={ValidatorRequired} errMsg={errors.keywords?.message} />
                <TextField label="Url to match" field="url" register={register} required={ValidatorUrl} errMsg={errors.url?.message} />
                
                <div className="row">
                     <SearchEngineList labels={availableEngines} register={register} errMsg={errors} />
                    <p className="errors">{errors.searchEngines?.message}</p>
                </div>
                <div className="row">  
                    
                    <SearchButton isWaiting={isWaiting} />
                    
                </div>
            </form>
        </>
    )
}