import React from "react";


export default function TextField({ fieldlabel, value, onTextChange }) {

    //const [error, setError] = useState('');
    function handleTextareaChange(e) {
        onTextChange(e.target.value);
        //if (!value.trim()) {
        //    setError('This field is required.');
        //} else {
        //    setError('');
        //}

    }
    return (
        <label>
            {fieldlabel}:
            <input
                type="text"
                value={value}
                required
                //ref={inputRef}
                onChange={handleTextareaChange}               
                style={{ margin: '10px' }}
            />
        </label>

    )
}