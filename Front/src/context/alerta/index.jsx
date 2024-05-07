import React, { useEffect, useState } from "react";

export const AlertaContext = React.createContext();
AlertaContext.displayName = 'Alert';

export const AlertaProvider = ({ children }) => {
    var [message, setMessage] = useState('');
    var [variant, setVariant] = useState('danger');
    var [show, setShow] = useState(false);

    async function handleShow(){
        setTimeout(() => {
            setShow(false)
        }, 5000)
    }

    useEffect(() => {
        handleShow()
    }, [show])

    return(
        <AlertaContext.Provider
            value={{
                message,
                setMessage,
                variant,
                setVariant,
                show,
                setShow
            }}
        >
            {children}
        </AlertaContext.Provider>
    )
}