import { createContext, useState, useEffect } from 'react';
import axios from 'axios';
import { useContext } from 'react';

const CountContext = createContext();

const CountContextComponent = (props) => {
    const [pendingCount, setPendingCount] = useState(0);
    const [confirmedCount, setConfirmedCount] = useState(0);
    const [refusedCount, setRefusedCount] = useState(0);

    const refreshCount = async () => {
        const { data } = await axios.get('/api/candidate/getpendingcount');
        setPendingCount(data.count);
        refreshConfirmedCount();
        refreshRefusedCount();
        
    }
    const refreshConfirmedCount = async () => {
        const { data } = await axios.get('/api/candidate/getconfirmedcount');
        setConfirmedCount(data.count);
    }
    const refreshRefusedCount = async () => {
        const { data } = await axios.get('/api/candidate/getrefusedcount');
        setRefusedCount(data.count);
    }

    useEffect(() => {
        refreshCount();
    }, []);

    const obj = {
        pendingCount,
        confirmedCount,
        refusedCount,
        refreshCount,
    }

    return < CountContext.Provider value={obj}>
        {props.children}
    </ CountContext.Provider >
}

const useCount = () => {
    return useContext(CountContext);
}

export default CountContextComponent;
export { useCount };
