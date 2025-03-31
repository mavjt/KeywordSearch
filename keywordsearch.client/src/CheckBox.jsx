import { React } from "react";

export default function Checkbox({  register, labelObj }) {
    // handle checkbox change
    //const handleChange = () => {
    //    updateValue(!value, name);
    //};
    // render the checkbox
    return (
        <>
            <input type="checkbox" id={`${labelObj.name}-checkbox`} value={labelObj.name}   {...register("searchEngines", { required: "At least one search engine required" })} />
            <label htmlFor={`${labelObj.name}-checkbox`} >{labelObj.name}</label>
        </>
    );
};
