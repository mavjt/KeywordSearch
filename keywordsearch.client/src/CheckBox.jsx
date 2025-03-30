import { React } from "react";

export default function Checkbox({ name, value = false, updateValue = () => { }, children }) {
    // handle checkbox change
    const handleChange = () => {
        updateValue(!value, name);
    };
    // render the checkbox
    return (
        <div className="py-2">
            <input type="checkbox" id={`${name}-checkbox`} name={name} checked={value} onChange={handleChange} />
            <label htmlFor={`${name}-checkbox`} >{children}</label>
        </div>
    );
};
