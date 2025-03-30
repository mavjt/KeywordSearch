import React from "react";

export default function TextField({ label, field, register, required, errMsg }) {
    
    return (
            <div className="row">
                <div className="col-25">
                <label htmlFor={field} >{label}</label>
                </div>
                <div className="col-75">
                    <input
                    type="text"
                    id={field}
                        //value={value}
                    {...register(field, required)}
                       // {required: `${label} required` })}
                        //ref={inputRef}
                        //onChange={handleTextareaChange}
                        style={{ margin: '10px' }}
                    />

                <p className="errors">{errMsg}</p>
                </div>
            </div>

        
        )

}
